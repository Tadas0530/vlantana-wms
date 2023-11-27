import apiClient from "@/utils/api-client"

function updatePallet(items, pallet_id, company_id) {
    return apiClient.put('/pallet', {...mapPallet(items), pallet_id, company_id} , { withCredentials: true })
    .then(response => {
    })
    .catch(error => {
        console.error('Error fetching pallet data:', error);
    });
}

function createPallet(items, company_id) {
    return apiClient.post('/pallets', {...mapPallet(items), company_id} , { withCredentials: true })
    .then(response => {
        // EventBus.emit('add-pallet', { ...response.data, is_defective: response.data.is_defective ? 'Taip' : 'Ne' });
    })
    .catch(error => {
        console.error('Error fetching pallet data:', error);
    });
}

function deletePallet(palletId) {
    return apiClient.post('/pallet/delete', { palletId: palletId }, { withCredentials: true })
    .then(response => {
    })
    .catch(error => {
        console.error('Error fetching pallet data:', error);
    });
}

function mapPallet(pallet) {
    return { 
        name: pallet[5].value,
        barcode: pallet[0].value,
        quantity: pallet[7].value,
        is_defective: pallet[3].value === 'Taip' ? true : false,
        location: pallet[4].value,
        status: pallet[6].value,
        date_arrived: pallet[1].value,
        date_exported: pallet[2].value,
    };
}

export default {
    updatePallet,
    createPallet,
    deletePallet
}