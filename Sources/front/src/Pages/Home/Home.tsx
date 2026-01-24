import { useGetProfile } from "../../Hooks/Profile/useGetProfile";

export default function Home() {
  const { data: profile } = useGetProfile();

  return <h1>{`Welcome, ${profile?.lastName} ${profile?.firstName}`!}</h1>;
}
