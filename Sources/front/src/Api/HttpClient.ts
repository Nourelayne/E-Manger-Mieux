import axios from "axios";
import { UnauthenticatedError } from "../Shared/Errors/UnauthenticatedError";
import { ApiError } from "../Shared/Errors/ApiError";

const httpClient = (baseURL: string) => {
  const client = axios.create({
    baseURL,
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
      "X-CSRF": "1",
    },
  });

  client.interceptors.response.use(
    (response) => response,
    (error: unknown) => {
      if (axios.isAxiosError(error)) {
        const status = error.response?.status;
        const message =
          error.response?.data?.message ?? error.message ?? "Unexpected error";

        if (status === 401) {
          throw new UnauthenticatedError();
        }

        throw new ApiError(message, status);
      }

      throw error;
    },
  );

  return client;
};

export const bffClient = httpClient("/bff");
export const apiClient = httpClient("/api");
