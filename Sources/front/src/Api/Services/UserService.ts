import { bffClient } from "../HttpClient";
import type { Claim } from "../Models/Claim";

export const getUser = async (): Promise<Claim[]> => {
  const { data } = await bffClient.get<Claim[]>("/user");
  return data;
};
