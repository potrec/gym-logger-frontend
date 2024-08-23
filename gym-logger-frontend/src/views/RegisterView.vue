<template>
  <div class="flex justify-center w-screen h-screen items-center text-black">
    <div class="flex flex-col bg-panel items-center m-16 rounded-md w-3/4 lg:w-3/8 xl:w-1/4">
      <h1 class="text-4xl mt-4 font-bold">Register</h1>
      <div class="flex flex-col w-1/2 rounded-lg mt-6">
        <label for="username">Username</label>
        <input
          class="mt-1 border-2 border-solid border-slate-600 rounded-lg pl-2"
          type="text"
          id="username"
        />
      </div>
      <div class="flex flex-col w-1/2 mt-6">
        <label for="email">Email</label>
        <input
          class="mt-1 border-2 border-solid border-slate-600 rounded-lg pl-2"
          type="email"
          id="email"
        />
      </div>
      <div class="flex flex-col w-1/2 mt-6">
        <label for="password">Password</label>
        <input
          class="mt-1 border-2 border-solid border-slate-600 rounded-lg pl-2"
          type="password"
          id="password"
        />
      </div>
      <div class="flex flex-col w-1/2 mt-6">
        <label for="confirmPassword">Confirm Password</label>
        <input
          class="mt-1 border-2 border-solid border-slate-600 rounded-lg pl-2"
          type="password"
          id="confirmPassword"
        />
      </div>
      <button
        class="bg-primary text-white pt-2 px-6 rounded-md border-2 border-solid border-slate-600 mt-6"
      >
        Register
      </button>
      Already have an account? <router-link to="/login">Login</router-link>
    </div>
  </div>
</template>

<script lang="ts">
export default {
  name: 'RegisterView'
}
</script>

<style scoped></style>
