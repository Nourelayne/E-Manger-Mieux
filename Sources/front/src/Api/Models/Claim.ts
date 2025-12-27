type ClaimType = "name" | "sid" | "picture";

export interface Claim {
  type: ClaimType;
  value?: string | null;
}
