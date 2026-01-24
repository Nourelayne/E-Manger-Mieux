import { apiClient } from "../HttpClient";
import type { UserDto } from "../Models/Entities/UserDto";

export const getUser = async (): Promise<UserDto> => {
  const { data } = await apiClient.get<UserDto>("/users/me");
  return data;
};
