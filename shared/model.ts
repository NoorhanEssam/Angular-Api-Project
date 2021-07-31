export class suggestBooks {
    title!:string;
    imagePath!:string;
    id!:number;
}


export class Book {
    title!:string;
    imagePath!:string;
    id!:number;
    serailNumber!:string;
    authorId!:number;
    publishDate!:Date;
    categoryId!:number;
    publisherId!:number;
    bookPath!:string;
    summary!:string;
    BookFile!: File ;
    ImageFile!:File ;
    countDownload!:number;
}

export class category {
    id!:number;
    name!:string;
    description!:string;
}

export class publishers {
    id!:number;
    name!:string;
    address!:string;
    phone!:string;
    fax!:string;
    webSite!:string;
    email!:string;
}

export class author {
    id!:number;
    fullName!:string;
    emial!:string;
    publisherId!:number;

}
export class quotes {
    id!:number;
    authorId!:string;
    author!:string;
    bookId!:number;
    book!:string;
    quotes!:string;

}
export class User {
    constructor(
        public userName: string,
        public Email: string,
        public Password: string,
        public confirmPassword: string,
       
    ) { }
}