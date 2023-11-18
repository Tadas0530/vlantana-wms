<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class CompanySeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        $company_names = ['UAB Ledai', 'Uab Retal',
            'Inverta', 'Vlantana', 'UAB Neogroup',
            'Uab Vtek'];

        foreach ($company_names as $value) {
            DB::table('companies')->insert([
                'company_name' => $value,
            ]);
        }
    }
}
