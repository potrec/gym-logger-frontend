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
    component: () => import('@/views/diet/DietPlanningView.vue')
  },
  {
    path: '/dietplanning/add',
    name: 'addMeal',
    component: () => import('@/views/diet/AddMealView.vue')
  },
  {
    path: '/dietplanning/change',
    name: 'changeDiet',
    component: () => import('@/views/diet/ChangeDietView.vue')
  },
  {
    path: '/workouts',
    name: 'workoutsShedule',
    component: () => import('@/views/workout/WorkoutsView.vue')
  },
  {
    path: '/workouts/edit',
    name: 'workoutsSheduleEdit',
    component: () => import('@/views/workout/WorkoutsSheduleEditView.vue')
  },
  {
    path: '/workouts/add',
    name: 'workoutsSheduleAdd',
    component: () => import('@/views/workout/WorkoutsSheduleAddView.vue')
  },
  {
    path: '/workouts/change',
    name: 'workoutsSheduleChange',
    component: () => import('@/views/workout/WorkoutsSheduleChangeView.vue')
  },
  {
    path: '/profile',
    name: 'profile',
    component: () => import('@/views/profile/ProfileView.vue')
  },
  {
    path: '/measurements',
    name: 'workoutsSheduleChange',
    component: () => import('@/views/profile/MeasurementsView.vue')
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
  },
  {
    path: '/about',
    name: 'about',
    component: () => import('@/views/AboutView.vue')
  }
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: routes
})

export default router
