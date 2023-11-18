<?php

namespace App\Http\Controllers;

use App\Models\Company;
use App\Models\Pallet;
use App\Models\Product;
use Illuminate\Http\JsonResponse;
use Illuminate\Http\Request;

class ProductController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index(Request $request)
    {
        $company_id = $request->input('company_id');
        $order_type = $request->input('order_type');

        $products = Product::where('company_id', $company_id)
            ->orderBy($order_type)
            ->offset($request->input('offset'))
            ->limit($request->input('limit'))
            ->get();

        return new JsonResponse($products);
    }

    public function findByBarcode(Request $request) {
        $company = auth()->user()->company;
        $product = Product::where('barcode', $request->input('barcode'))
            ->where('company_id', $company->id)
            ->first();
        return response()->json($product);
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {

    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        $pallet = Pallet::find($request->input('pallet_id'));
        $company = Company::find($request->input('company_id'));

        if (!$company || !$pallet) {
            return new JsonResponse(['error' => 'Pallet or company does not exist :(']);
        }

        $product = Product::create([
            'barcode' => $request->input('barcode'),
            'name' => $request->input('name'),
            'description' => $request->input('description'),
            'status' => $request->input('status'),
            'production_date' => $request->input('production_date'),
            'expiry_date' => $request->input('expiry_date')
        ]);

        $pallet->products()->save($product);
        $company->products()->save($product);

        return new JsonResponse($product);
    }

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        return new JsonResponse(Product::findOr($id, function() {
            return ['error' => 'Could not find the product'];
        }));
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(string $id)
    {

    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $id)
    {
        $product = Product::find($id);
        $pallet = Pallet::find($request->input('pallet_id'));

        if (!$pallet) {
            return new JsonResponse(['error' => 'Product must have a pallet!']);
        }

        $product->update([
            'barcode' => $request->input('barcode'),
            'name' => $request->input('name'),
            'description' => $request->input('description'),
            'status' => $request->input('status'),
            'production_date' => $request->input('production_date'),
            'expiry_date' => $request->input('expiry_date')
        ]);

        $pallet->products()->save($product);

        return new JsonResponse($pallet);
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id)
    {
        $product = Product::find($id);
        $product->delete();
    }
}
