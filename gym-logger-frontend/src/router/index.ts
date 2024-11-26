import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    name: 'home',
    component: () => import('@/views/HomeView.vue')
  },
  {
    path: '/login',
    name: 'login',
    component: () => import('@/views/LoginView.vue')
  },
  {
    path: '/register',
    name: 'register',
    component: () => import('@/views/RegisterView.vue')
  },
  {
    path: '/color',
    name: 'color',
    component: () => import('@/views/ColorView.vue')
  },
  {
    path: '/:pathMatch(.*)*',
    name: 'error',
    component: () => import('@/views/ErrorView.vue')
  },
  {
    path: '/component',
    name: 'component',
    component: () => import('@/views/ComponentTestView.vue')
  },
  {
    path: '/dashboard',
    name: 'dashboard',
    component: () => import('@/views/DashboardView.vue')
  },
  {
    path: '/dietplanning',
    name: 'dietplanning',
    component: () => import('@/views/DietPlanningView.vue')
  },
  {
    path: '/workouts',
    name: 'workouts',
    component: () => import('@/views/WorkoutsView.vue')
  },
  {
    path: '/support',
    name: 'support',
    component: () => import('@/views/SupportView.vue')
  },
  {
    path: '/settings',
    name: 'settings',
    component: () => import('@/views/SettingsView.vue')
  }
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: routes
})

export default router
