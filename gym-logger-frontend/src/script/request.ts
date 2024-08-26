export type UserLogin = { email: string; password: string }
export type UserRegister = { userName: string; email: string; password: string }

export const login = async (user: UserLogin): Promise<Response> => {
  return fetch(process.env.BACKEND_API_URL + '/login', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(user)
  })
}

export const register = async (user: UserRegister): Promise<Response> => {
  return fetch(process.env.BACKEND_API_URL + 'http://localhost:3000/register', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(user)
  })
}

export const getUserData = async (token: string): Promise<Response> => {
  return fetch(process.env.BACKEND_API_URL + '/user', {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
      Authorization: `Bearer ${token}`
    }
  })
}
