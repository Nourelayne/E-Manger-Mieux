import { useMutation, useQueryClient } from "@tanstack/react-query";
import { completeProfile } from "../../Api/Services/ProfileService";
import { useNavigate } from "react-router-dom";
import type { CompleteProfileDto } from "../../Api/Models/DTOs/CompleteProfileDto";

export const useCompleteProfile = () => {
  const navigate = useNavigate();
  const query = useQueryClient();

  return useMutation<CompleteProfileDto, Error, CompleteProfileDto>({
    mutationFn: (values) => {
      const completeProfileDto: CompleteProfileDto = {
        ...values,
      };
      return completeProfile(completeProfileDto);
    },
    onSuccess: () => {
      query.invalidateQueries({ queryKey: ["get", "user"] });
      query.invalidateQueries({ queryKey: ["get", "profile"] });
      navigate("/");
    },
    onError: () => navigate("/error"),
  });
};
