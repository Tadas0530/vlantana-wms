<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Hash;

class RoleSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        $roles = ['Operatorius', 'Vadovas', 'Klientas', 'Darbuotojas'];

        foreach ($roles as $role) {
            DB::table('roles')->insert([
                'role_name' => $role
            ]);
        }
    }
}
