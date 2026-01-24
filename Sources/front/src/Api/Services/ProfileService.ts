import { apiClient } from "../HttpClient";
import type { CompleteProfileDto } from "../Models/DTOs/CompleteProfileDto";
import type { ProfileDto } from "../Models/Entities/ProfileDto";

export const getProfile = async (): Promise<ProfileDto> => {
  const { data } = await apiClient.get<ProfileDto>("/profiles/me");
  return data;
};

export const completeProfile = async (
  completeProfileDto: CompleteProfileDto,
): Promise<CompleteProfileDto> => {
  const { data } = await apiClient.put<CompleteProfileDto>(
    `/profiles/me/complete`,
    completeProfileDto,
  );
  return data;
};
