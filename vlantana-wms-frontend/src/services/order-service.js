import apiClient from "@/utils/api-client"

function getOrdersWithPallets() {
    return apiClient.get('/order-preparation', { withCredentials: true })
        .then(response => response.data)
        .catch(error => {
            console.error('Error fetching pallet data:', error);
            throw error;
        });
}

export default {
    getOrdersWithPallets
}