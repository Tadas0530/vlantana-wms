<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\HasMany;

class Company extends Model
{
    use HasFactory;

    protected $fillable = [
        'company_name'
    ];

    public function products() : HasMany {
        return $this->hasMany(Product::class);
    }

    public function pallets() : HasMany {
        return $this->hasMany(Pallet::class);
    }

    public function orders() : HasMany {
        return $this->hasMany(Order::class);
    }

    public function users() : HasMany {
        return $this->hasMany(User::class);
    }
}
