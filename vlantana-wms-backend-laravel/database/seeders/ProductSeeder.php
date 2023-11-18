<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Str;

class ProductSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
//        'pallet_id',
//        'barcode',
//        'order_id',
//        'company_id',
//        'name',
//        'description',
//        'status',
//        'production_date',
//        'expiry_date',

        for ($i = 0; $i < 2000; $i++) {
            DB::table('products')->insert([
                'name' => fake()->randomElement(['Ledai', 'Kamštukai', 'Žuvis', 'Vištiena', 'Kiauliena', 'Trąšos']),
                'company_id' => rand(1, 6),
                'pallet_id' => rand(1, 200),
                'order_id' => null,
                'barcode' => Str::random(20),
                'description' => fake()->sentence,
                'status' => 'Sukurtas',
                'production_date' => $this->generateRandomDate(),
                'expiry_date' => $this->generateRandomDate()
            ]);
        }
    }

    public function generateRandomDate($startDate = '1970-01-01', $endDate = 'now') {
        // Convert the start and end dates to timestamps
        $startTimestamp = strtotime($startDate);
        $endTimestamp = strtotime($endDate);

        // Generate a random timestamp between start and end
        $randomTimestamp = mt_rand($startTimestamp, $endTimestamp);

        // Convert the random timestamp to a date string
        return date('Y-m-d H:i:s', $randomTimestamp);
    }
}
