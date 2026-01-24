interface IconProps {
  name: string;
  size?: number;
  weight?: number;
  fill?: 0 | 1;
  grade?: number;
  decorative?: boolean;
}

export function Icon({
  name,
  size = 24,
  weight = 400,
  fill = 0,
  grade = 0,
  decorative = true,
}: IconProps) {
  return (
    <span
      className="material-symbols-outlined"
      aria-hidden={decorative}
      style={{
        fontSize: size,
        fontVariationSettings: `
          'FILL' ${fill},
          'wght' ${weight},
          'GRAD' ${grade},
          'opsz' ${size}
        `,
        cursor: "pointer",
      }}
    >
      {name}
    </span>
  );
}
