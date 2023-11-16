<?php

namespace App\Http\Controllers;

use App\Models\Company;
use App\Models\Order;
use App\Models\Pallet;
use Illuminate\Http\JsonResponse;
use Illuminate\Http\Request;

class OrderController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index(Request $request)
    {
        $company_id = $request->input('company_id');
        $order_type = $request->input('order_type');

        $products = Order::where('company_id', $company_id)
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

    /**
     * Store a newly created resource in storage.
     */
    //'description',
    //'company_id'
    public function store(Request $request)
    {
        $company = Company::find($request->input('company_id'));

        if (!$company) {
            return new JsonResponse(["error" => "Pallet must belong to an existing company"]);
        }

        $order = Order::create([
            'description' => $request->input('description'),
            'status' => $request->input('status')
        ]);

        $company->orders()->save($order);

        return new JsonResponse($order);
    }

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        return new JsonResponse(Order::findOr($id, function() {
            return ['error' => 'Could not find the order'];
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
        $order = Order::find($id);
        $company = Company::find($request->input('company_id'));

        if (!$company) {
            return new JsonResponse(["error" => "Pallet must belong to an existing company"]);
        }

        $order->create([
            'description' => $request->input('description'),
            'status' => $request->input('status')
        ]);

        $company->orders()->save($order);

        return new JsonResponse($order);
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id)
    {
        $order = Order::find($id);
        $order->delete();
    }
}
