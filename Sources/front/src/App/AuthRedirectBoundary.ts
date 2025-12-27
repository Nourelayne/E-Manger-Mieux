import { useEffect } from "react";
import { useQueryClient } from "@tanstack/react-query";
import { UnauthenticatedError } from "../Shared/Errors/UnauthenticatedError";

export function AuthRedirectBoundary() {
  const queryClient = useQueryClient();

  useEffect(() => {
    const unsubscribe = queryClient.getQueryCache().subscribe((event) => {
      const error = event?.query?.state?.error;

      if (error instanceof UnauthenticatedError) {
        window.location.href = "/bff/login";
      }
    });

    return unsubscribe;
  }, [queryClient]);

  return null;
}
