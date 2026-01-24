import "./Layout.scss";
import { type ReactElement } from "react";
import UserAvatar from "../Shared/Components/Avatar";
import { useGetUser } from "../Hooks/User/useGetUser";
import { useLocation } from "react-router-dom";
import { ProfileForm } from "../Pages/ProfileForm/ProfileForm";
import { useGetProfile } from "../Hooks/Profile/useGetProfile";

const titles: Record<string, string> = {
  "/profile": "Profile",
};

const Layout = ({ children }: { children: ReactElement | ReactElement[] }) => {
  const { data: user, isError, isLoading } = useGetUser();
  const { data: profile } = useGetProfile();

  const location = useLocation();

  console.log(user);

  if (isLoading || !user) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error...</div>;
  }

  if (!user.isVerified) {
    return (
      <main>
        <article>
          <section>
            <ProfileForm />
          </section>
        </article>
      </main>
    );
  }

  return (
    <main className="container">
      <aside className="drawer">
        <div className="profile">
          <UserAvatar
            alt={`${profile?.lastName} ${profile?.firstName} avatar`}
            //src={profile?.avatarUrl}
            src={""}
          />
          <h4>{`${profile?.lastName} ${profile?.firstName}`}</h4>
        </div>
      </aside>
      <article className="content">
        <h1>{titles[location.pathname]}</h1>
        <section>{children}</section>
      </article>
    </main>
  );
};

export default Layout;
