<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Str;

class PalletSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        for ($i = 0; $i < 200; $i++) {
            DB::table('pallets')->insert([
                'company_id' => rand(1, 6),
                'order_id' => null,
                'name' => 'Paletė ' . fake()->randomElement(['Ledai', 'Kamštukai', 'Žuvis', 'Vištiena', 'Kiauliena', 'Trąšos']),
                'barcode' => Str::random(15),
                'quantity' => rand(1, 100),
                'is_defective' => fake()->randomElement([true, false]),
                'location' => rand(0, 6) . strtoupper(fake()->randomLetter) . sprintf("%02d", rand(0, 31)) .
                    fake()->randomElement(["A", "B", "C", "D", "E"]) . rand(1, 4),
                'status' => 'Sukurtas',
                'date_arrived' => $this->generateRandomDate(),
                'date_exported' => $this->generateRandomDate()
            ]);
        }
    }

    public function generateRandomDate($startDate = '1970-01-01', $endDate = 'now')
    {
        // Convert the start and end dates to timestamps
        $startTimestamp = strtotime($startDate);
        $endTimestamp = strtotime($endDate);

        // Generate a random timestamp between start and end
        $randomTimestamp = mt_rand($startTimestamp, $endTimestamp);

        // Convert the random timestamp to a date string
        return date('Y-m-d H:i:s', $randomTimestamp);
    }
}
