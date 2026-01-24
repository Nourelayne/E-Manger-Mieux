import type { ProfileDto } from "../../Api/Models/Entities/ProfileDto";
import { useGetProfile } from "../../Hooks/Profile/useGetProfile";
import { Icon } from "../../Shared/Components/Icon";
import { useForm } from "react-hook-form";
import "./ProfileForm.scss";
import { useEffect } from "react";
import { useCompleteProfile } from "../../Hooks/Profile/useCompleteProfile";

export type TProfileForm = Pick<
  ProfileDto,
  "firstName" | "lastName" | "dateOfBirth" | "gender" | "height" | "weight"
>;

export const ProfileForm = () => {
  const { data: profile } = useGetProfile();
  const { mutate } = useCompleteProfile();

  const { handleSubmit, register, reset } = useForm<TProfileForm>({
    mode: "onSubmit",
  });

  useEffect(() => {
    reset({
      firstName: profile?.firstName,
      lastName: profile?.lastName,
      dateOfBirth: profile?.dateOfBirth,
      height: profile?.height,
      weight: profile?.weight,
    });
  }, [profile, reset]);

  const onClick = (values: TProfileForm) => mutate(values);

  return (
    <form className="profile-form">
      <div className="profile-form__avatar">
        <img alt="user avatar" /*src={profile?.avatarUrl}*/ src="" />
        <div className="profile-form__avatar__update">
          <input {...register("firstName")} type="file" />
          <Icon name="edit" />
        </div>
      </div>
      <>
        <div className="profile-form__field">
          <label htmlFor="first-name">First name</label>
          <div className="profile-form__field__actions">
            <input {...register("firstName")} type="text" />
            {/* <Icon name="edit" />
            <Icon name="save" /> */}
          </div>
        </div>
        <div className="profile-form__field">
          <label htmlFor="last-name">Last name</label>
          <div className="profile-form__field__actions">
            <input {...register("lastName")} type="text" />
            {/* <Icon name="edit" />
            <Icon name="save" /> */}
          </div>
        </div>
        <div className="profile-form__field">
          <label htmlFor="age">Date of birth</label>
          <div className="profile-form__field__actions">
            <input {...register("dateOfBirth")} type="date" />
            {/* <Icon name="edit" />
            <Icon name="save" /> */}
          </div>
        </div>
        <div className="profile-form__field">
          <label htmlFor="age">Date of birth</label>
          <div className="profile-form__field__actions">
            <select {...register("gender")}>
              <option value="">Select gender</option>
              <option value="Male">Male</option>
              <option value="Female">Female</option>
              <option value="Other">Other</option>
            </select>
            {/* <Icon name="edit" />
            <Icon name="save" /> */}
          </div>
        </div>
        <div className="profile-form__field">
          <label htmlFor="height">Height</label>
          <div className="profile-form__field__actions">
            <input {...register("height")} type="number" />
            {/* <Icon name="edit" />
            <Icon name="save" /> */}
          </div>
        </div>
        <div className="profile-form__field">
          <label htmlFor="weight">Weight</label>
          <div className="profile-form__field__actions">
            <input
              {...register("weight")}
              type="number"
              disabled={profile?.weight !== null}
            />
            {/* <Icon name="edit" />
            <Icon name="save" /> */}
          </div>
        </div>
        <button type="submit" onClick={handleSubmit(onClick)}>
          Valider
        </button>
      </>
    </form>
  );
};
