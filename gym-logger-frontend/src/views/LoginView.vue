<template>
  <div class="container mx-auto p-4 mt-8">
    <Form @submit="handleLogin">
      <FormField v-slot="{ componentField }" name="email">
        <FormItem>
          <FormLabel>Email</FormLabel>
          <FormControl>
            <Input type="email" placeholder="Enter your email" v-bind="componentField" />
          </FormControl>
          <FormDescription />
          <FormMessage />
        </FormItem>
      </FormField>
      <FormField v-slot="{ componentField }" name="password">
        <FormItem>
          <FormLabel>Password</FormLabel>
          <FormControl>
            <Input type="password" placeholder="Enter your password" v-bind="componentField" />
          </FormControl>
          <FormDescription />
          <FormMessage />
        </FormItem>
      </FormField>
      <Button type="submit">Login</Button>
      <p class="mt-4">
        No account? <a href="/register" class="text-blue-500 hover:underline">Sign Up</a>
      </p>
    </Form>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { useForm } from 'vee-validate'
import { toTypedSchema } from '@vee-validate/zod'
import * as z from 'zod'

import { Button } from '@/components/ui/button'
import { Form, FormField, FormItem, FormLabel, FormControl, FormDescription, FormMessage } from '@/components/ui/form'
import { Input } from '@/components/ui/input'

const router = useRouter()

const loginSchema = toTypedSchema(z.object({
  email: z.string().email(),
  password: z.string().min(8)
}))

const form = useForm({
  validationSchema: loginSchema,
})

async function handleLogin(values: any) {
  // Add your login logic here
  console.log('Login data:', values)
  // Redirect to home after successful login
  router.push('/')
}
</script>
