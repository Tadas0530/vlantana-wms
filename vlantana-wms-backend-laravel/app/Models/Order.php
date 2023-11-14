<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\HasMany;

class Order extends Model
{
    use HasFactory;

    protected $fillable = [
        'description',
        'company_id'
    ];

    public function products() : HasMany {
        return $this->hasMany(Product::class);
    }

    public function pallets() : HasMany {
        return $this->hasMany(Pallet::class);
    }


}
