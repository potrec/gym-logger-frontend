<template>
  <div class="flex w-screen h-screen items-center justify-center">
    <div class="flex flex-col w-1/2 h-1/2 justify-evenly bg-page-accent p-6">
      <Input label="Username" type="text" id="username" :icon="['fas', 'user']" />
      <Input label="Email" type="email" id="email" :icon="['fas', 'at']" />
      <Input label="Password" type="password" id="password" :icon="['fas', 'lock']" />
      <Input
        label="Confirm Password"
        type="password"
        id="confirmPassword"
        :icon="['fas', 'user']"
      />
    </div>
  </div>
</template>

<script setup lang="ts">
import Input from '@/components/common/InputComponent.vue'
</script>
