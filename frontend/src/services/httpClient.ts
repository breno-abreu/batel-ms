import router from '@/router'

type RequestOptions = Omit<RequestInit, 'body'> & {
  body?: unknown
}

export class HttpError extends Error {
  status: number

  constructor(status: number) {
    super(`Erro na requisição: ${status}`)
    this.name = 'HttpError'
    this.status = status
  }
}

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL ?? ''

function redirectByStatus(status: number): void {
  const routeNameByStatus: Record<number, string> = {
    401: 'unauthorized',
    404: 'not-found'
  }

  const routeName = routeNameByStatus[status]

  if (!routeName || router.currentRoute.value.name === routeName) {
    return
  }

  void router.push({ name: routeName })
}

async function request<TResponse>(path: string, options: RequestOptions = {}): Promise<TResponse> {
  const { body, headers, ...requestOptions } = options
  const requestHeaders = new Headers(headers)

  if (!requestHeaders.has('Content-Type')) {
    requestHeaders.set('Content-Type', 'application/json')
  }

  const response = await fetch(`${API_BASE_URL}${path}`, {
    ...requestOptions,
    headers: requestHeaders,
    body: body !== undefined ? JSON.stringify(body) : undefined
  })

  if (!response.ok) {
    redirectByStatus(response.status)
    throw new HttpError(response.status)
  }

  if (response.status === 204) {
    return undefined as TResponse
  }

  return response.json() as Promise<TResponse>
}

export const httpClient = {
  get: <TResponse>(path: string, options?: RequestOptions) =>
    request<TResponse>(path, { ...options, method: 'GET' }),
  post: <TResponse>(path: string, body?: unknown, options?: RequestOptions) =>
    request<TResponse>(path, { ...options, method: 'POST', body }),
  put: <TResponse>(path: string, body?: unknown, options?: RequestOptions) =>
    request<TResponse>(path, { ...options, method: 'PUT', body }),
  patch: <TResponse>(path: string, body?: unknown, options?: RequestOptions) =>
    request<TResponse>(path, { ...options, method: 'PATCH', body }),
  delete: <TResponse>(path: string, options?: RequestOptions) =>
    request<TResponse>(path, { ...options, method: 'DELETE' })
}
