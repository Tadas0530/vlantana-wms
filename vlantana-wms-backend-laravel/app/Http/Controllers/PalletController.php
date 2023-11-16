<?php

namespace App\Http\Controllers;

use App\Models\Company;
use App\Models\Order;
use App\Models\Pallet;
use App\Models\Product;
use Illuminate\Http\JsonResponse;
use Illuminate\Http\Request;

class PalletController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index(Request $request)
    {
        $company_id = $request->input('company_id');
        $order_type = $request->input('order_type');

        $products = Pallet::where('company_id', $company_id)
            ->orderBy($order_type)
            ->offset($request->input('offset'))
            ->limit($request->input('limit'))
            ->get();

        return new JsonResponse($products);
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        //
    }

//'company_id',
//'order_id',
//'quantity',
//'is_defective',
//'location',
//'status',
//'date_arrived',
//'date_exported'

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        $company = Company::find($request->input('company_id'));
        $order = Order::find($request->input('order_id'));

        if (!$company) {
            return new JsonResponse(["error" => "Pallet must belong to an existing company"]);
        }

        $pallet = Pallet::create([
            'barcode' => $request->input('barcode'),
            'quantity' => $request->input('quantity'),
            'is_defective' => $request->input('is_defective'),
            'location' => $request->input('location'),
            'status' => $request->input('status'),
            'date_arrived' => $request->input('date_arrived'),
            'date_exported' => $request->input('date_exported')
        ]);

        $company->pallets()->save($pallet);

        if ($order) {
            $order->pallets()->save($pallet);
        }

        return new JsonResponse($pallet);
    }

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        return new JsonResponse(Pallet::findOr($id, function() {
            return ['error' => 'Could not find the pallet'];
        }));
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(string $id)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $id)
    {
        $pallet = Pallet::find($id);
        $company = Company::find($request->input('company_id'));

        if (!$company) {
            return new JsonResponse(["error" => "Pallet must belong to an existing company"]);
        }

        $pallet->update([
            'barcode' => $request->input('barcode'),
            'quantity' => $request->input('quantity'),
            'is_defective' => $request->input('is_defective'),
            'location' => $request->input('location'),
            'status' => $request->input('status'),
            'date_arrived' => $request->input('date_arrived'),
            'date_exported' => $request->input('date_exported')
        ]);

        return new JsonResponse($pallet);
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id)
    {
        $product = Pallet::find($id);
        $product->delete();
    }
}
