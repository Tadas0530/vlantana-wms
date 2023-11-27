import apiClient from "@/utils/api-client"

function getOrdersWithPallets() {
    return apiClient.get('/order-preparation', { withCredentials: true })
        .then(response => response.data)
        .catch(error => {
            console.error('Error fetching pallet data:', error);
            throw error;
        });
}

function deleteOrder(orderId) {
    return apiClient.post('/order/delete', { orderId }, { withCredentials: true })
    .then(response => {
    })
    .catch(error => {
        console.error('Error fetching pallet data:', error);
    });
}

function setOrderStatus(orderId, status) {
    return apiClient.post('/order/status', { orderId, status }, { withCredentials: true })
    .then(response => {
    })
    .catch(error => {
        console.error('Error fetching pallet data:', error);
    });
}

function updateOrder(data) {
    return apiClient.post('/order/status', data, { withCredentials: true })
    .then(response => {
    })
    .catch(error => {
        console.error('Error fetching pallet data:', error);
    });
}

export default {
    getOrdersWithPallets,
    deleteOrder,
    setOrderStatus,
    updateOrder
}