export interface ProfileDto {
  firstName?: string;
  lastName?: string;
  dateOfBirth?: string;
  gender?: "Male" | "Female" | "Other";
  height?: number;
  //heightUnit?: "Cm" | "In";
  weight?: number;
  //weightUnit?: "Kg" | "Lb";
  //avatarUrl?: string;
}
