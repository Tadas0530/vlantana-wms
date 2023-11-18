<?php

use App\Http\Controllers\AuthController;
use App\Http\Controllers\CompanyController;
use App\Http\Controllers\DriverController;
use App\Http\Controllers\OrderController;
use App\Http\Controllers\PalletController;
use App\Http\Controllers\ProductController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider and all of them will
| be assigned to the "api" middleware group. Make something great!
|
*/

Route::middleware('api')->prefix('v1')->group(function () {

    // auth
    Route::post('/register', [AuthController::class, 'register'])->name("register");
    Route::post('/login', [AuthController::class, 'login'])->name("login");

    //

    Route::middleware(['jwt.from.cookie', 'jwt.auth'])->group(function () {
        Route::get('/auth/check', [AuthController::class, 'checkAuth']);

        Route::resource('/products', ProductController::class);
        Route::get('/products/barcode', [ProductController::class, 'findByBarcode']);

        Route::resource('/companies', CompanyController::class);

        Route::resource('/orders', OrderController::class);

        Route::resource('/drivers', DriverController::class);

        Route::resource('/pallets', PalletController::class);
        Route::get('/pallet/barcode', [PalletController::class, 'findByBarcode']);

        Route::get('/test-jwt', function() {
           return "You have permission";
        });
    });

    Route::get('/echo', function (Request $request) {
        return "Dirbam dirbam dirbam";
    });

    Route::middleware('role.level:1,2,3')->group(function () {

    });
});
