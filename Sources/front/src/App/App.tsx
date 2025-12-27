import { Route, Routes } from 'react-router-dom';
import Home from '../Pages/Home/Home';
import { AuthRedirectBoundary } from './AuthRedirectBoundary';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';

  const queryClient = new QueryClient();

const App = () => (
  <QueryClientProvider client={queryClient}>
    <AuthRedirectBoundary />
    <Routes>
      <Route path="/" element={<Home />} />
    </Routes>
  </QueryClientProvider>
)

export default App
