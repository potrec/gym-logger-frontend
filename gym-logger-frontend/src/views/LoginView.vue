<template>
  <div class="flex shadow-2xl flex-col">
    <div class="flex">
      <div class="flex flex-col w-1/2 h-1/2 justify-evenly bg-page-accent p-6 w-3/5">
        <Input label="Email" type="email" id="email" :icon="['fas', 'at']" />
        <Input label="Password" type="password" id="password" :icon="['fas', 'lock']" />
        <button class="bg-primary text-white py-2 px-4 rounded">Login</button>
      </div>
      <div class="bg-primary-accent w-2/5">
        <h1 class="text-4xl text-white mx-2 my-2">Welcome</h1>
      </div>
    </div>
    <div class="bg-primary-accent text-sm text-white p-2">
      Don't have an account? <router-link to="/register">Click here to register</router-link>
    </div>
  </div>
</template>

<script setup lang="ts">
import Input from '@/components/common/InputComponent.vue'
</script>
