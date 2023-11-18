// Composables
import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    component: () => import('@/layouts/default/Default.vue'),
  },
  {
    path: '/authentication',
    component: () => import('@/pages/AuthenticationPage.vue'),
  },
  {
    path: '/app',
    component: () => import('@/pages/MainPage.vue'),
    children: [
      {
        path: 'dashboard',
        name: 'Dashboard',
        component: () => import('@/pages/screens/MainScreen.vue'),
      },
      {
        path: 'assigned-orders',
        name: 'Assigned orders',
        component: () => import('@/pages/screens/OrderPrepScreen.vue'),
      },
      {
        path: 'orders',
        name: 'Orders',
        component: () => import('@/pages/screens/OrderScreen.vue'),
      },
      {
        path: 'inventory',
        name: 'Inventory',
        component: () => import('@/pages/screens/InventoryScreen.vue'),
      },
      {
        path: 'scan',
        name: 'Scan',
        component: () => import('@/pages/screens/ScanScreen.vue'),
      },
    ],
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
})

export default router
