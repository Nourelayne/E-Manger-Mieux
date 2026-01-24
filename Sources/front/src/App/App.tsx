import { AuthRedirectBoundary } from "./AuthRedirectBoundary";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import Router from "./Router/Router";
import Layout from "../Layout/Layout";

const queryClient = new QueryClient();

const App = () => {
  console.log("Hu");
  return (
    <QueryClientProvider client={queryClient}>
      <AuthRedirectBoundary />
      <Layout>
        <Router />
      </Layout>
    </QueryClientProvider>
  );
};

export default App;
