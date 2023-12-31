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
        Schema::create('pallets', function (Blueprint $table) {
            $table->id();
            $table->string('barcode');
            $table->string('name');
            $table->integer("company_id")->nullable();
            $table->integer("order_id")->nullable();
            $table->integer("quantity");
            $table->boolean("is_defective");
            $table->string("location");
            $table->string("status");
            $table->dateTime("date_arrived");
            $table->dateTime("date_exported");
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('pallets');
    }
};
