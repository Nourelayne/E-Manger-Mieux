import { Avatar, Badge, styled } from "@mui/material";
import type { ComponentProps } from "react";

const StyledBadge = styled(Badge)(({ theme }) => ({
  "& .MuiBadge-badge": {
    backgroundColor: "#44b700",
    color: "#44b700",
    boxShadow: `0 0 0 2px ${theme.palette.background.paper}`,
    "&::after": {
      position: "absolute",
      width: "100%",
      height: "100%",
      borderRadius: "50%",
      animation: "ripple 1.2s infinite ease-in-out",
      border: "1px solid currentColor",
      content: '""',
    },
  },
  "@keyframes ripple": {
    "0%": {
      transform: "scale(0.8)",
      opacity: 1,
    },
    "100%": {
      transform: "scale(2.4)",
      opacity: 0,
    },
  },
}));

type TUserAvatar = ComponentProps<"img">;

const UserAvatar = ({ alt, src, ...props }: TUserAvatar) => (
  <StyledBadge
    overlap="circular"
    anchorOrigin={{ vertical: "bottom", horizontal: "right" }}
    variant="dot"
  >
    <Avatar alt={alt} src={src} {...props} />
  </StyledBadge>
);

export default UserAvatar;
