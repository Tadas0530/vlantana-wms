<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\HasMany;

class Order extends Model
{
    use HasFactory;
    protected static function boot()
    {
        parent::boot();

        // Before the parent model is deleted, set the parent_id of its children to null
        static::deleting(function ($parent) {
            $parent->pallets()->update(['order_id' => null]);
        });
    }

    protected $fillable = [
        'description',
        'order_code',
        'status',
        'company_id'
    ];

    public function products() : HasMany {
        return $this->hasMany(Product::class);
    }

    public function pallets() : HasMany {
        return $this->hasMany(Pallet::class);
    }


}
