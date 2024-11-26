<template>
  <div class="p-4">
    <h2 class="text-3xl font-bold mb-6">Support and Community</h2>

    <Card>
      <CardHeader>
        <CardTitle>FAQ and Tips</CardTitle>
      </CardHeader>
      <CardContent>
        <Accordion type="single" class="w-full" collapsible :default-value="faqDefaultValue">
          <AccordionItem v-for="(item, index) in faqItems" :key="index" :value="item.value">
            <AccordionTrigger>{{ item.question }}</AccordionTrigger>
            <AccordionContent>
              {{ item.answer }}
            </AccordionContent>
          </AccordionItem>
        </Accordion>
      </CardContent>
    </Card>

    <Card class="mt-6">
      <CardHeader>
        <CardTitle>Community Forum</CardTitle>
      </CardHeader>
      <CardContent>
        <MessageList :messages="communityMessages" />
      </CardContent>
    </Card>

    <Card class="mt-6">
      <CardHeader>
        <CardTitle>Contact Support</CardTitle>
      </CardHeader>
      <CardContent>
        <Form @submit.prevent="sendSupportMessage">
          <Input class="mb-4" v-model="supportMessage" placeholder="Your message here..." />
          <Button type="submit">Send</Button>
        </Form>
      </CardContent>
    </Card>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card'
import { Accordion, AccordionContent, AccordionItem, AccordionTrigger } from '@/components/ui/accordion'

import { Input } from '@/components/ui/input'
import { Button } from '@/components/ui/button'

const faqItems = ref([
  {
    "value": "item-1",
    "question": "How do I reset my password?",
    "answer": "You can reset your password by clicking on the 'Forgot Password' link on the login page."
  },
  {
    "value": "item-2",
    "question": "How do I update my profile information?",
    "answer": "You can update your profile information by going to the 'Profile' section in your account settings."
  },
  {
    "value": "item-3",
    "question": "QUESTION HERE",
    "answer": "ANSWER HERE"
  }
])

const communityMessages = ref([])

const supportMessage = ref('')
const sendSupportMessage = () => {
  console.log('Sending support message:', supportMessage.value)
}

const faqDefaultValue = ref('item-1')
</script>
