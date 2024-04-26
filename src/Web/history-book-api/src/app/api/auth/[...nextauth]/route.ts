import NextAuth, { NextAuthOptions } from "next-auth"

const handler = NextAuth({
  secret: process.env.NEXTAUTH_SECRET,
  callbacks: {
    async jwt({ token, user, account }) 
    {
      return { ...token, ...user };
    },
    async session({ session, token, user }) {
      session.user = token;
      return session;
    },
    // async redirect({ url, baseUrl }) {
    //   if (url.startsWith("/api/auth/signin?error=OAuthCallback")) return `${baseUrl}/api/auth/signin/identity-server4`
    //   // Allows callback URLs on the same origin
    //   else if (new URL(url).origin === baseUrl) return url
    //   return baseUrl
    // }
  },
  providers: [
    {
      id: "identity-server4",
      name: "IdentityServer4",
      type: "oauth",
      wellKnown: `http://host.docker.internal:5026/.well-known/openid-configuration`,
      authorization: { params: { scope: "openid email roles profile" } },
      checks: ["pkce", "state"],
      clientId: "client-next",
      clientSecret: "client2123",
      issuer: "http://host.docker.internal:5026",
      userinfo: "http://host.docker.internal:5026/connect/userinfo",
      profile(profile: any, token: any) {
        return {
          id: profile.sub,
          name: profile.name,
          email: profile.email,
          image: null,
          access_token: token.access_token,
          role: profile.role
        }
      },
    },
  ],
  session: { strategy: "jwt" },
  jwt: {
    maxAge: 60 * 60 * 24 * 30
  }
})


export { handler as GET, handler as POST }