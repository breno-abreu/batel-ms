# Frontend Batel MS

Frontend do Batel MS com Vite, Vue 3, Options API e TypeScript.

## Padrões

- Use o alias `@` para imports a partir de `src`.
- Use `fetch` para chamadas HTTP, preferencialmente via `src/services/httpClient.ts`.
- Não use Axios neste projeto.

Exemplo:

```ts
import { httpClient } from '@/services/httpClient'

type HealthResponse = {
  status: string
}

const health = await httpClient.get<HealthResponse>('/health')
```
