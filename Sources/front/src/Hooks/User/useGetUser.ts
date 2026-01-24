import { useQuery } from "@tanstack/react-query";
import { getUser } from "../../Api/Services/UserService";
import type { UserDto } from "../../Api/Models/Entities/UserDto";

export const useGetUser = () =>
  useQuery<UserDto>({
    queryKey: ["get", "user"],
    queryFn: getUser,
    retry: false,
  });
