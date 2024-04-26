import { NextRequestWithAuth, withAuth } from "next-auth/middleware"
import { NextResponse } from "next/server";

export default withAuth(
    function middlware(request: NextRequestWithAuth) {
        console.log(request.nextauth.token)
        var isChecked: boolean = request.nextUrl.pathname.split(".").filter((item: string) => {
            return item == "js" || item == "json" || item == "ico" || item == "svg" || item == "gif" || item == "png" || item == "jpg";
        }).length > 0;

        if(!isChecked) {
            if(request.nextauth.token == null) {
                const url = request.nextUrl.clone();

                url.pathname = "/denied";

                return NextResponse.redirect(url);
            } else {
                return NextResponse.next();
            }
        } else {
            return NextResponse.next();
        }
    }
);