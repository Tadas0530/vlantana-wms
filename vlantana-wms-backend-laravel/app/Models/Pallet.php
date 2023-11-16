<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;
use Illuminate\Database\Eloquent\Relations\HasMany;

class Pallet extends Model
{
    use HasFactory;

    protected $fillable = [
        'company_id',
        'order_id',
        'barcode',
        'quantity',
        'is_defective',
        'location',
        'status',
        'date_arrived',
        'date_exported'
    ];

    public function company() : BelongsTo {
        return $this->belongsTo(Company::class);
    }

    public function order() : BelongsTo {
        return $this->belongsTo(Order::class);
    }

    public function products() : HasMany {
        return $this->hasMany(Product::class);
    }
}
