<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('products', function (Blueprint $table) {
            $table->id();
            $table->integer("pallet_id");
            $table->integer("order_id");
            $table->integer("company_id");
            $table->string("name", 100);
            $table->string("description", 500);
            $table->string("status", 100);
            $table->dateTime("production_date");
            $table->dateTime("expiry_date");
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('products');
    }
};
