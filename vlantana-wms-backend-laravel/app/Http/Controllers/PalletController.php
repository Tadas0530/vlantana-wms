<?php

namespace App\Http\Controllers;

use App\Models\Company;
use App\Models\Order;
use App\Models\Pallet;
use App\Models\Product;
use App\Models\User;
use Illuminate\Http\JsonResponse;
use Illuminate\Http\Request;

class PalletController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index(Request $request)
    {
        $user = auth()->user();
        $company_id = $user->company_id;

        $order_type = $request->query('order_type') != null ? $request->query('order_type') : 'date_arrived';
        $order_asc = $request->query('order_asc') != null ? $request->query('order_asc') : 'asc';

        $page = max((int)$request->query('page', 1), 1); // Ensures minimum page number is 1
        $limit = max((int)$request->query('limit', 25), 1); // Ensures minimum limit is 1

        $offset = ($page - 1) * $limit;

        $pallets = Pallet::where('company_id', $company_id)
            ->orderBy($order_type)
            ->offset($offset)
            ->limit($limit)
            ->get();

        return new JsonResponse($pallets);
    }

    public function getPalletsByCompany(Request $request)
    {
        $companyId = $request->input('companyId');

        $user = auth()->user();

        // validation
        if ($user->company_id != 4 && $user->role->id != 4)
        {
            return response()->json('Unauthorized', 401);
        }

        $order_type = $request->query('order_type') != null ? $request->query('order_type') : 'date_arrived';
        $order_asc = $request->query('order_asc') != null ? $request->query('order_asc') : 'asc';

        $page = max((int)$request->query('page', 1), 1); // Ensures minimum page number is 1
        $limit = max((int)$request->query('limit', 25), 1); // Ensures minimum limit is 1

        $offset = ($page - 1) * $limit;

        $pallets = Pallet::where('company_id', $companyId)
            ->orderBy($order_type)
            ->offset($offset)
            ->limit($limit)
            ->get();

        return new JsonResponse($pallets);
    }

    public function findByBarcode(Request $request): JsonResponse
    {
        $company = auth()->user()->company;

        if ($company->id == 4)
        {
            $pallet = Pallet::where('barcode', $request->input('barcode'))->first();
            return response()->json($pallet);
        }

        $pallet = Pallet::where('barcode', $request->input('barcode'))
            ->where('company_id', $company->id)
            ->first();
        return response()->json($pallet);
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

        if (!$company) {
            return new JsonResponse(["error" => "Pallet must belong to an existing company"]);
        }

        $pallet = Pallet::create([
            'name' => $request->input('name'),
            'barcode' => $request->input('barcode'),
            'quantity' => $request->input('quantity'),
            'is_defective' => $request->input('is_defective'),
            'location' => $request->input('location'),
            'status' => $request->input('status'),
            'date_arrived' => $request->input('date_arrived'),
            'date_exported' => $request->input('date_exported')
        ]);

        $company->pallets()->save($pallet);

        return new JsonResponse($pallet);
    }

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        return new JsonResponse(Pallet::findOr($id, function () {
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
    public function updatePallet(Request $request)
    {
        $pallet = Pallet::find($request->input('pallet_id'));
        $company = Company::find($request->input('company_id'));

        if (!$company) {
            return new JsonResponse(["error" => "Pallet must belong to an existing company"]);
        }

        $pallet->update([
            'name' => $request->input('name'),
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
    public function destroyById(Request $request)
    {
        $validation = $request->validate([
            'palletId' => 'required|integer'
        ]);

        $product = Pallet::find($validation['palletId']);
        $product->delete();
    }
}
