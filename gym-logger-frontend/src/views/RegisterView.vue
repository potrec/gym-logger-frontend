<template>
  <div class="container mx-auto p-4 mt-8">
    <Form @submit="handleRegister">
      <FormField v-slot="{ componentField }" name="username">
        <FormItem>
          <FormLabel>Username</FormLabel>
          <FormControl>
            <Input type="text" placeholder="Choose a username" v-bind="componentField" />
          </FormControl>
          <FormDescription />
          <FormMessage />
        </FormItem>
      </FormField>
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
            <Input type="password" placeholder="Create a strong password" v-bind="componentField" />
          </FormControl>
          <FormDescription />
          <FormMessage />
        </FormItem>
      </FormField>
      <FormField v-slot="{ componentField }" name="confirmPassword">
        <FormItem>
          <FormLabel>Confirm Password</FormLabel>
          <FormControl>
            <Input type="password" placeholder="Re-enter your password" v-bind="componentField" />
          </FormControl>
          <FormDescription />
          <FormMessage />
        </FormItem>
      </FormField>
      <Button type="submit">Register</Button>
      <p class="mt-4">
        You have account? <a href="/login" class="text-blue-500 hover:underline">Log in</a>
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

const registerSchema = toTypedSchema(z.object({
  username: z.string().min(3).max(20),
  email: z.string().email(),
  password: z.string().min(8),
  confirmPassword: z.string().refine((val, ctx) => val === ctx.parent.password)
}))

const form = useForm({
  validationSchema: registerSchema,
})

async function handleRegister(values: any) {
  // Add your registration logic here
  console.log('Registration data:', values)
  // Redirect to login after successful registration
  router.push('/login')
}
</script>
