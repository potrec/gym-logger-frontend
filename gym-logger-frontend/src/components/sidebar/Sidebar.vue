<!-- components/Sidebar.vue -->
<template>
  <div class="fixed inset-y-0 left-0 w-72 bg-primary text-white p-8">
    <div class="space-y-6">
      <a href="/" class="block py-2 px-4 hover:bg-gray-700">Home</a>
      <a href="/dashboard" class="block py-2 px-4 hover:bg-gray-700">Dashboard</a>
      <a href="/about" class="block py-2 px-4 hover:bg-gray-700">About</a>
      <div class="py-2 px-4">
        <span class="font-semibold">Diet planning</span>
        <ul class="mt-2 space-y-1">
          <li><a href="/dietplanning" class="block py-2 px-4 hover:bg-gray-700">Meal history</a></li>
          <li><a href="/dietplanning/add" class="block py-2 px-4 hover:bg-gray-700">Add meal</a></li>
          <li><a href="/dietplanning/change" class="block py-2 px-4 hover:bg-gray-700">Change diet</a></li>
        </ul>
      </div>
      <div class="py-2 px-4">
        <span class="font-semibold">Workouts</span>
        <ul class="mt-2 space-y-1">
          <li><a href="/workouts" class="block py-2 px-4 hover:bg-gray-700">Workouts history</a></li>
          <li><a href="/workouts/add" class="block py-2 px-4 hover:bg-gray-700">Schedule workout</a></li>
          <li><a href="/workouts/edit" class="block py-2 px-4 hover:bg-gray-700">Edit workout</a></li>
          <li><a href="/workouts/change" class="block py-2 px-4 hover:bg-gray-700">Change workout mode</a></li>
        </ul>
      </div>
      <div class="py-2 px-4">
        <span class="font-semibold">Profile</span>
        <ul class="mt-2 space-y-1">
          <li><a href="/profile" class="block py-2 px-4 hover:bg-gray-700">Profile</a></li>
          <li><a href="/measurements" class="block py-2 px-4 hover:bg-gray-700">Edit measurements</a></li>
        </ul>
      </div>
      <a href="/settings" class="block py-2 px-4 hover:bg-gray-700">Settings</a>
      <a href="/support" class="block py-2 px-4 hover:bg-gray-700">Support</a>
      <a href="/settings" class="block py-2 px-4 hover:bg-gray-700">Log out</a>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

const isOpen = ref(false)
</script>
