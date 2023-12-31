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
        $company = auth()->user()->company;
        $order_type = $request->query('order_type') != null ? $request->query('order_type'): 'created_at';

        $page = max((int) $request->query('page', 1), 1); // Ensures minimum page number is 1
        $limit = max((int) $request->query('limit', 25), 1); // Ensures minimum limit is 1

        $offset = ($page - 1) * $limit;

        $orders = Order::where('company_id', $company->id)
            ->orderBy($order_type)
            ->offset($offset)
            ->limit($limit)
            ->get();

        return new JsonResponse($orders);
    }

    public function getOrdersByCompany(Request $request) {
        $companyid = $request->input('companyId');

        $order_type = $request->query('order_type') != null ? $request->query('order_type'): 'created_at';

        $page = max((int) $request->query('page', 1), 1); // Ensures minimum page number is 1
        $limit = max((int) $request->query('limit', 25), 1); // Ensures minimum limit is 1

        $offset = ($page - 1) * $limit;

        $orders = Order::where('company_id', $companyid)
            ->orderBy($order_type)
            ->offset($offset)
            ->limit($limit)
            ->get();

        return new JsonResponse($orders);
    }

    public function getOrdersWithPallets() {
        $orders = Order::with('pallets')->get();
        return response()->json(Order::with('pallets')->get());
    }

    public function setOrderStatus(Request $request) {
        $data = $request->validate([
            'orderId' => 'required|integer',
            'status' => 'required|string|max:30'
        ]);

        $order = Order::find($data['orderId']);
        $order->status = $data['status'];
        $order->save();

        return response()->json($order);
    }

    public function getOrdersWithPalletsByCompany(Request $request) {

        $data = $request->validate([
           'companyId' => 'required|integer|exists:companies,id'
        ]);

        return response()->json(Order::where('company_id', $data['companyId'])->with('pallets')->get());
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
    public function store(Request $request)
    {
        $user = auth()->user();
        $company = null;

        if ($request->input('companyId')) {
            $company = Company::find($request->input('companyId'));
        } else {
            $company = Company::find($user->company_id);
        }
        $pallet_ids = $request->input('pallet_ids');

        if (!$company) {
            return new JsonResponse(["error" => "Pallet must belong to an existing company"]);
        }

        $order = Order::create([
            'order_code' => null,
            'description' => $request->input('description'),
            'status' => $request->input('status')
        ]);

        if (!$order) {
            return new JsonResponse(['error' => 'failed to create the order']);
        }

        $order->update([
            'order_code' => $company->company_name . '-' . sprintf("%06d", $order->id)
        ]);

        $company->orders()->save($order);
        Pallet::whereIn('id', $pallet_ids)->update(['order_id' => $order->id]);

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
    public function updateOrder(Request $request)
    {
        $order = Order::find($request->input('orderId'));
        $company = Company::find($request->input('companyId'));

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
    public function destroyById(Request $request)
    {
        $validation = $request->validate([
            'orderId' => 'required|integer'
        ]);

        $order = Order::find($validation['orderId']);
        $order->delete();
    }
}
