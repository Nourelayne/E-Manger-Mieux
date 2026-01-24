import { useQuery } from "@tanstack/react-query";
import type { ProfileDto } from "../../Api/Models/Entities/ProfileDto";
import { getProfile } from "../../Api/Services/ProfileService";

export const useGetProfile = () =>
  useQuery<ProfileDto>({
    queryKey: ["get", "profile"],
    queryFn: getProfile,
  });
