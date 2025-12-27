import { useQuery } from "@tanstack/react-query";
import { getUser } from "../../Api/Services/UserService";
import type { User } from "../../Api/Models/User";
import type { Claim } from "../../Api/Models/Claim";

export const useGetUser = () =>
  useQuery<Claim[], Error, User>({
    queryKey: ["user"],
    queryFn: getUser,
    retry: false,
    select: (data) => {
      const sid = data.find((d) => d.type === "sid")?.value;

      if (!sid) throw new Error("User SID missing");

      return {
        sid,
        name: data.find((d) => d.type === "name")?.value ?? undefined,
        avatar: data.find((d) => d.type === "picture")?.value ?? undefined,
      };
    },
  });
