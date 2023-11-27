import apiClient from "@/utils/api-client";

function updatePallet() {
    apiClient.get('/pallets', { withCredentials: true })
    .then(response => {
        this.palletData = response.data.map(p => { return { ...p, is_defective: p.is_defective ? 'Taip' : 'Ne' } });
        this.isLoading = false;
    })
    .catch(error => {
        console.error('Error fetching pallet data:', error);
        this.isLoading = false;
    });
}

export default {
    updatePallet,
}