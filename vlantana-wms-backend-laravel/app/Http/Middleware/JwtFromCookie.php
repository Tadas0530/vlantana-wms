<?php

namespace App\Http\Middleware;

use Closure;
use Illuminate\Http\Request;
use Symfony\Component\HttpFoundation\Response;

class JwtFromCookie
{
    /**
     * Handle an incoming request.
     *
     * @param  \Closure(\Illuminate\Http\Request): (\Symfony\Component\HttpFoundation\Response)  $next
     */
    public function handle(Request $request, Closure $next): Response
    {
        // Check if the request has a cookie named 'jwt'
        if ($request->hasCookie('jwt')) {
            // Extract the token from the cookie
            $token = $request->cookie('jwt');

            // Attach the token to the Authorization header
            $request->headers->set('Authorization', 'Bearer ' . $token);
        }

        return $next($request);
    }
}
