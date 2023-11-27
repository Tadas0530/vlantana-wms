<?php

namespace App\Http\Controllers;

use App\Models\User;
use Illuminate\Http\JsonResponse;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\Cookie;
use Illuminate\Support\Facades\Hash;
use Tymon\JWTAuth\Exceptions\JWTException;
use Tymon\JWTAuth\Facades\JWTAuth;

class AuthController extends Controller
{
    public function login(Request $request): JsonResponse
    {
        $credentials = $request->only(['email', 'password']);

        if (!$token = auth()->attempt($credentials)) {
            return response()->json(['error' => 'Unauthorized'], 401);
        }

        $cookie = Cookie::make(
            'jwt',
            $token,
            60 * 24 * 7, // 7 days
            '/', // Path
            null, // Domain, use null to automatically use the current domain
            false, // Secure
            true, // HttpOnly
            false, // Raw
            'lax' // SameSite, use 'lax' for local development without HTTPS
        );

        $user = User::find(Auth::id());

        $userData = [
            'name' => $user->name,
            'email' => $user->email,
            'company_id' => $user->company_id,
            'role' => $user->role,
        ];

        return $this->respondWithToken($token, $userData)->withCookie($cookie);
    }

    public function register(Request $request) : JsonResponse
    {
        $credentials = $request->validate([
            'name' => 'required|string|max:255',
            'email' => 'required|string|email|max:255|unique:users',
            'password' => 'required|string|min:6',
            'company_id' => 'required',
            'role' => 'required'
        ]);

        $user = User::create([
            'name' => $request->name,
            'email' => $request->email,
            'password' => Hash::make($request->password),
            'company_id' => $request->company_id,
            'role' => $request->role,
        ]);

        $token = auth()->login($user);
        $cookie = Cookie::make(
            'jwt',
            $token,
            60 * 24 * 7, // 7 days
            '/', // Path
            null, // Domain, use null to automatically use the current domain
            false, // Secure
            true, // HttpOnly
            false, // Raw
            'lax' // SameSite, use 'lax' for local development without HTTPS
        );

        $userData = [
            'name' => $user->name,
            'email' => $user->email,
            'company_id' => $user->company_id,
            'role' => $user->role,
        ];

        return $this->respondWithToken($token, $userData)->withCookie($cookie);
    }

    public function checkAuth(Request $request)
    {
        // Attempt to get the authenticated user using the jwt guard
        $user = auth('api')->user();;

        // Check if a user was found
        $isAuthenticated = $user !== null;

        return response()->json([
            'isAuthenticated' => $isAuthenticated
        ]);
    }

    public function logout(Request $request)
    {
        try {
            // Get the token from the request header
            $token = $request->header('Authorization');

            // Try to invalidate the token
            JWTAuth::setToken($token)->invalidate();

            // If the token has been invalidated, return a success response
            return response()->json(['message' => 'User successfully logged out'], 200);
        } catch (JWTException $e) {
            // Something went wrong whilst attempting to encode the token
            return response()->json(['message' => 'Failed to logout, please try again'], 500);
        }
    }

    protected function respondWithToken($token, $user): JsonResponse
    {
        return response()->json([
            'access_token' => $token,
            'token_type' => 'bearer',
            'status' => 'success',
            'expires_in' => auth('api')->factory()->getTTL() * 60,
            'user' => $user
        ]);
    }
}
