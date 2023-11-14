<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;
class Driver extends Model
{
    use HasFactory;

    protected $fillable = [
        'user_id',
        'license_from',
        'certificate_number'
    ];

    public function user() : belongsTo {
        return $this->belongsTo(User::class);
    }
}
