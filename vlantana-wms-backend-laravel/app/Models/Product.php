<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;

class Product extends Model
{
    use HasFactory;

    protected $fillable = [
        'pallet_id',
        'order_id',
        'company_id',
        'name',
        'description',
        'status',
        'production_date',
        'expiry_date',
    ];

    public function pallet() : BelongsTo {
        return $this->belongsTo(Pallet::class);
    }

    public function order() : BelongsTo {
        return $this->belongsTo(Order::class);
    }

    public function company() : BelongsTo {
        return $this->belongsTo(Company::class);
    }
}
